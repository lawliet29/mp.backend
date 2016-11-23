import { Point, Polygon } from './shapes'

export interface ElementaryArea {
    id?: number,
    name: string,
    points: Array<Point>
    metadata?: { [key: string]: string },
    hover?: boolean,
    selected?: boolean,
    polygon?: Polygon,
    info?: { [key: string]: (string | {}) }
}