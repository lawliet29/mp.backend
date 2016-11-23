import * as React from 'react'
import * as Paper from 'paper'
import { WrappedCanvasContext, default as DrawingService } from '../../services/services.drawing'
import { Shape,  Shapes, Polygon } from '../../models/domain/shapes'
import * as $ from 'jquery'
import MapLoader from '../../services/services.mapLoader'
import ToolService from '../../services/services.toolService'
import AreaService from '../../services/services.areas'
import { ElementaryArea } from '../../models/domain/areas'

declare function require(name) : any;
const styles = require('../../styles/map/map.sass')

const MouseButton = {
    Left: 0,
    Right: 1,
    Middle: 2
};

export default class MapComponent extends React.Component<{}, {}> {
    private backgroundCanvas : HTMLCanvasElement
    private foregroundCanvas : HTMLCanvasElement
    private mouseCanvas : HTMLCanvasElement
    private $mouseCanvas : JQuery
    
    private background : WrappedCanvasContext
    private foreground : WrappedCanvasContext
    private mouse : WrappedCanvasContext
    
    private shapeSpace : Array<Shape>
    
    private loggingArea : HTMLElement
    
    private canvasRect : ClientRect;
    
    private hoverAreas : Array<ElementaryArea> = [];
    
    private updateAreas: () => void
    
    private setHighlight: (number, boolean) => void
    
    constructor(props) {
        super(props);
        this.updateAreas = _.debounce(AreaService.triggerAreasChange, 500);
        this.setHighlight = _.debounce(AreaService.setHighlight, 500);
    }
    
    componentDidMount() {
        
        this.background = DrawingService.wrap(this.backgroundCanvas.getContext('2d'));
        this.foreground = DrawingService.wrap(this.foregroundCanvas.getContext('2d'));
        this.mouse = DrawingService.wrap(this.mouseCanvas.getContext('2d'));
        this.$mouseCanvas = $(this.mouseCanvas);
        
        // dirty hack: actually use background client bounding rectangle because it all
        // goes haywire when 3 canvas elements are positioned on top of each other        
        
        const canvasComponents = [ this.background, this.foreground, this.mouse ].map(c => c.context.canvas);
        const onResize = (ev : UIEvent) => {
            const width = window.innerWidth * 0.75 - 20;
            const height = window.innerHeight * 0.8;
            
            canvasComponents.forEach(c => {
                c.width = width;
                c.height = height;
            })
            
            this.canvasRect = this.background.context.canvas.getBoundingClientRect();
            
            this.forceUpdate();
            
            this.renderAreas();
        }
        
        window.onresize = onResize;
        
        $('canvas').on('contextmenu', () => false);
                
        const mouseCanvas = this.mouse.context.canvas;
        
        mouseCanvas.onmousemove = this.handleMouseMove.bind(this);  
        mouseCanvas.oncontextmenu = this.handleClick.bind(this);      
        mouseCanvas.onclick = this.handleClick.bind(this);
        
        MapLoader.onMapLoaded(this.renderMap.bind(this));
        const currentImage = MapLoader.getCurrentMap();
        if (currentImage) {
            this.renderMap(currentImage);
        }
        
        AreaService.onAreasChange(this.renderAreas.bind(this));
    }
    
    handleMouseMove(evt : MouseEvent) {
        const mouseCanvas = this.mouse.context.canvas;
        const rect = this.canvasRect;
        const x = (evt.clientX - rect.left) / rect.width * mouseCanvas.width;
        const y = (evt.clientY - rect.top) / rect.height * mouseCanvas.height;
        
        const mousePoint = Shapes.Point(x,y);
        
        this.loggingArea.innerText = `X: ${x}, Y: ${y}, cX: ${evt.clientX}, xY: ${evt.clientY}`;
        this.mouse.clear();
        const currentTool = ToolService.getCurrentTool();
        if (currentTool == "draw") {
            
            const shapes : Array<Shape> = [ mousePoint ];
            
            const editArea = AreaService.getCurrentEditArea();
            if (editArea && editArea.points.length !== 0) {
                const lastPoint = editArea.points[editArea.points.length - 1];
                shapes.push(Shapes.Line(lastPoint, mousePoint))
            }
            
            this.mouse.clear();
            this.mouse.draw(shapes);
        }
        else if (currentTool == "selection") {
            const areas = _.values(AreaService.getElementaryAreas()) as Array<ElementaryArea>;
            const hoverAreas = [];
            areas.forEach(a => {
                let hover = DrawingService.isWithinPolygon(mousePoint, a.polygon);
                if (hover) {
                    hoverAreas.push(a);
                }
                
                this.setHighlight(a.id, hover);
            });
            
            if (this.hoverAreas.length != hoverAreas.length) {
                this.hoverAreas = hoverAreas;
                this.updateAreas();
            }
            
            if (hoverAreas.length > 0) {
                this.$mouseCanvas.css('cursor', 'pointer');
            }
            else {
                this.$mouseCanvas.css('cursor', 'default');
            }
        }
    }
    
    handleClick(evt : MouseEvent) {
        const mouseCanvas = this.mouse.context.canvas;
        const rect = this.canvasRect;
        const x = (evt.clientX - rect.left) / rect.width * mouseCanvas.width;
        const y = (evt.clientY - rect.top) / rect.height * mouseCanvas.height;
        
        var currentTool = ToolService.getCurrentTool();
        if (currentTool == "selection") {
            this.hoverAreas.forEach(a => a.selected = true);
            AreaService.triggerAreasChange();
        }
        else if (currentTool == "edit") {
            // bang
        }
        else if (currentTool == "draw") {            
            var editArea = AreaService.getCurrentEditArea();
            if (evt.button === MouseButton.Left) {
                editArea.points.push(Shapes.Point(x, y));
                editArea.polygon = Shapes.Polygon(editArea.points, false);
            }
            else {
                editArea.polygon = Shapes.Polygon(editArea.points, true);
                editArea.points = editArea.polygon.points;
                AreaService.clearEditArea();
            }
            
            AreaService.triggerAreasChange();
        }
        
        evt.preventDefault();
        evt.stopPropagation();
        return false;
    }
    
    renderAreas() {
        const areas = AreaService.getElementaryAreas();
        const editArea = AreaService.getCurrentEditArea();
        const editAreaId = editArea ? editArea.id : NaN;
        
        var polygons : Array<Polygon> = [];
        
        for (let id in areas) {
            let area = areas[id];
            
            if (!area.polygon) {
                area.polygon = Shapes.Polygon(area.points, area.id !== editAreaId)
            }
            
            polygons.push(area.polygon);
        }
        
        this.foreground.clear();
        this.foreground.draw(polygons);
    }
    
    renderMap(img : HTMLImageElement) {
        let canvas = this.background.context.canvas;
        var hRatio = canvas.width / img.width    ;
        var vRatio = canvas.height / img.height  ;
        var ratio  = Math.min ( hRatio, vRatio );
        this.background.context.drawImage(img, 0,0, img.width, img.height, 0,0,img.width*ratio, img.height*ratio);
    }
    
    render() {
        return (
            <div className={styles.mapContainer}>
                <canvas id='background' ref={item => this.backgroundCanvas = item} />
                <canvas id='foreground' ref={item => this.foregroundCanvas = item} />
                <canvas id='mouse' ref={item => this.mouseCanvas = item} />
                <span ref={item => this.loggingArea = item} className={styles.log}></span>
            </div>
        )
    }
}