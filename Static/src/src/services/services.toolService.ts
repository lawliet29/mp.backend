import * as _ from 'lodash'
import * as $ from 'jquery'

export type Tool = "selection" | "edit" | "draw";
type ToolsType =  { [name: string]: { icon: string, name: string } };

const Tools : ToolsType = {
    "selection": {
        icon: "pointing up",
        name: "Указатель"
    },
    "edit": {
        icon: "edit",
        name: "Редактирование участка"
    },
    "draw": {
        icon: "pencil",
        name: "Рисование участка"
    }
}

var currentTool : Tool = _.keys(Tools)[0] as Tool;
const toolChangeCallbacks = $.Callbacks();

export interface ToolService {
    getTools() : ToolsType
    getCurrentTool() : Tool
    setTool(t : Tool)
    onToolChanged(callback : (Tool) => void)
}

const ToolServiceImplementation : ToolService = {
    getTools() { return _.cloneDeep(Tools) },
    getCurrentTool() { return currentTool },
    setTool(t: Tool) {
        currentTool = t;
        toolChangeCallbacks.fire(currentTool);
    },
    onToolChanged(callback) {
        toolChangeCallbacks.add(callback);
    }
}

export default ToolServiceImplementation;