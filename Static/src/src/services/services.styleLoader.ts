declare function require(name: string): any;

var styles = require('../styles/menu/menu.sass');

export function load(path: string) {
    return require(path);
}
