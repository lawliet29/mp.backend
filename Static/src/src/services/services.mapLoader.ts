import * as $ from 'jquery'

type ImageLoadedCallback = (HTMLImageElement) => void;

const MAP_KEY = 'map_image';

export interface MapLoader {
    load: (HTMLInputElement) => void
    onMapLoaded: (ImageLoadedCallback) => void
    getCurrentMap: (() => HTMLImageElement)
}

const mapCallbacks = $.Callbacks();
var currentMap : HTMLImageElement = null;

const MapLoaderImplementation : MapLoader = {
    load: (input : HTMLInputElement) => {
        const $input = $(input);
        $input.unbind('change');
        $input.change(event => {
            let file = input.files[0];
            let reader = new FileReader();
            reader.onload = img => {
                let element = document.createElement("img");
                element.src = reader.result;
                currentMap = element;
                mapCallbacks.fire(element);
            }
            reader.readAsDataURL(file);
        });
        $input.click();
    },
    onMapLoaded: callback => mapCallbacks.add(callback),
    getCurrentMap: () => currentMap
}

export default MapLoaderImplementation;