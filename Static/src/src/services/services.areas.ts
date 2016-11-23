import { ElementaryArea } from '../models/domain/areas'
import { Shapes, Point, Polygon } from '../models/domain/shapes'
import * as $ from 'jquery'
import * as _ from 'lodash'
import ToolService from '../services/services.toolService'

export interface AreaService {
    getElementaryAreas() : { [id : number]: ElementaryArea }
    addElementaryArea(area : ElementaryArea, id? : number) : void
    removeElementaryArea(id : number)
    onAreasChange(callback : Function)
    triggerAreasChange()
    addPoint(id : number, p : Point)
    setEditArea(id : number)
    getCurrentEditArea() : ElementaryArea,
    setHighlight(id : number, highlight : boolean),
    clearEditArea()
}

const ELEMENTARY_LOCAL_STORAGE_KEY = 'AreaService.elementaryAreas'

const safeParse = (json : string) => json ? JSON.parse(json) : {}; 

const defaultAreaService : AreaService = (() => {
    let elementaryAreas : { [id : number]: ElementaryArea } 
        = safeParse(window.localStorage.getItem(ELEMENTARY_LOCAL_STORAGE_KEY));
        
    const elementaryCallbacks = $.Callbacks();
    var editArea : ElementaryArea;
    let count = _.max(_.values(elementaryAreas).map((a : ElementaryArea) => a.id)) + 1;
    if (isNaN(count)) {
        count = 1;
    }
    
    $
    .get('http://localhost:8009/elementaryAreas/')
    .then(data => {
        elementaryAreas = data;
        elementaryCallbacks.fire(_.clone(elementaryAreas));
    });
    
    const getElementaryAreas = () => _.clone(elementaryAreas);
    
    const triggerAreasChange = () => { elementaryCallbacks.fire(getElementaryAreas()) };
    
    return {
        getElementaryAreas,
        addElementaryArea: function(area : ElementaryArea, id? : number) {
            const index = id || count++; 
            const newArea = _.clone(area);
            newArea.id = index;
            elementaryAreas[index] = newArea;
            elementaryCallbacks.fire(getElementaryAreas());
        },
        removeElementaryArea: function(id) {
            delete elementaryAreas[id];
            elementaryCallbacks.fire(getElementaryAreas());
        },
        onAreasChange: callback => elementaryCallbacks.add(callback),
        addPoint: (id, point) => elementaryAreas[id].points.push(point),
        setEditArea: id => {
            ToolService.setTool("draw");
            editArea = elementaryAreas[id];
            // TODO: make proper edit here
            editArea.points = [];
            editArea.polygon = Shapes.Polygon(editArea.points, false);
        },
        getCurrentEditArea: () => editArea,
        clearEditArea: () => {
            ToolService.setTool("selection");
            editArea = null;
        },
        setHighlight: function(id, highlight) {
            elementaryAreas[id].hover = highlight;
            elementaryAreas[id].polygon.color = highlight ? 'rgba(77, 163, 44, 0.4)' : null;
            triggerAreasChange();    
        },
        triggerAreasChange
    }
})();

defaultAreaService.onAreasChange(areas => {
    window.localStorage.setItem(ELEMENTARY_LOCAL_STORAGE_KEY, JSON.stringify(areas))    
});

var exportAreaService = defaultAreaService;

export default exportAreaService;