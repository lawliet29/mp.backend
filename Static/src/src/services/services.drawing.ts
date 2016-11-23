import { Shapes, Shape, Point, Polygon } from '../models/domain/shapes'

export interface DrawingService {
    wrap(context : CanvasRenderingContext2D) : WrappedCanvasContext
    isWithinPolygon: (point: Point, polygon: Polygon) => boolean
}

export interface WrappedCanvasContext {
    context: CanvasRenderingContext2D
    clear: () => void
    draw: (shapes: Array<Shape>) => void
}

const DefaultDrawingService : DrawingService = {
    wrap: (context : CanvasRenderingContext2D) => {
        var wrappedContext : WrappedCanvasContext = {
            context: context,
            clear: () => context.clearRect(0, 0, context.canvas.width, context.canvas.height),
            draw: (shapes : Array<Shape>) => { 
                context.strokeStyle = 'black';  
                        
                shapes.forEach(s => {
                    if (Shapes.isPoint(s)) {
                        context.beginPath();
                        context.arc(s.x, s.y, 3, 0, 2*Math.PI);
                        context.lineWidth = 0.5;
                    }
                    if (Shapes.isLine(s)) {
                        context.beginPath();
                        context.moveTo(s.from.x, s.from.y);
                        context.lineTo(s.to.x, s.to.y);
                        context.lineWidth = .5;
                    }
                    if (Shapes.isPolygon(s)) {
                        if (s.points.length < 2) {
                            return;
                        }
                        wrappedContext.draw(s.points);
                        context.beginPath();
                        context.moveTo(s.points[0].x, s.points[0].y);
                        for (let i = 1; i < s.points.length; i++) {
                            let {x, y} = s.points[i];
                            context.lineTo(x, y);
                        }
                        
                        if (s.closed) {
                            context.closePath();
                        }
                                                
                        context.lineWidth = 0.5;
                    }
                    
                    if (s.color) {
                        context.globalAlpha = 0.4;
                        context.fillStyle = s.color;
                        context.fill();
                        context.globalAlpha = 1;
                    }
                    context.stroke();
                });
            }
        }
        
        return wrappedContext;
    },
    
    isWithinPolygon: (point: Point, polygon: Polygon) => {
        if (!point || !polygon) {
            return false;
        }
        
        let {x, y} = point;
        let {points} = polygon;
        
        var inside = false;
        for (let i = 0, j = points.length - 1; i < points.length; j = i++) {
            let xi = points[i].x,
                yi = points[i].y,
                xj = points[j].x,
                yj = points[j].y
                
            let intersect = ((yi > y) != (yj > y)) && (x < (xj - xi) * (y - yi) / (yj - yi) + xi);
            if (intersect) inside = !inside;
        }
        
        return inside;
    }
}

var ExportDrawingService = DefaultDrawingService;
export default ExportDrawingService;