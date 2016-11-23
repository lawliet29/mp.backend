import {ElementaryArea} from './areas'

export interface Shape {
    color?: string
    parent?: ElementaryArea 
}

export interface Point extends Shape {    
    x: number;
    y: number;
}

export interface Line extends Shape {    
    from: Point;
    to: Point;
}

export interface Polygon extends Shape {
    points: Array<Point>
    closed: boolean
}



export const Shapes = {
    Point: (x: number, y: number) : Point => ({ x: x, y: y, color: 'green' }),
    isPoint: (p) : p is Point => 'x' in p && 'y' in p,
    Line: (from: Point, to: Point) : Line => ({ from: from, to: to }),
    LinesFromPolygon: (points : Array<Point>) : Array<Line> => {
        if (points.length < 2) { return []; }
        
        let result  = [];
        
        let previousPoint = points[0];
        for (let i = 1; i < points.length; i++) {
            let nextPoint = points[i];
            result.push(Shapes.Line(previousPoint, nextPoint));
            previousPoint = nextPoint;
        }
        
        result.push(Shapes.Line(points[points.length - 1], points[0]))
        
        return result;
    },
    isLine: (l) : l is Line => 'from' in l && 'to' in l,
    Polygon: (points : Array<Point>, closed : boolean = true) : Polygon => ({ points: points, closed: closed }),
    isPolygon: (p) : p is Polygon => 'points' in p && 'closed' in p,
};