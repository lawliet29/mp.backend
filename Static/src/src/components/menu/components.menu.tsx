import * as React from 'react'
import * as cx from 'classnames'
import * as _ from 'lodash'
import MapLoader from '../../services/services.mapLoader'
import {Tool, default as ToolService} from '../../services/services.toolService'

type State = {
    selectedTool: Tool
}

export default class Menu extends React.Component<{}, State> {
    
    private fileLoader : HTMLInputElement;
    
    constructor() {
        super();
        this.state = {
            selectedTool: ToolService.getCurrentTool()
        };
        ToolService.onToolChanged(t => this.setState({ selectedTool: t }))
    }
    
    loadMap() {
        MapLoader.load(this.fileLoader);
    }
    
    render() {
        
        const tools = ToolService.getTools();
        
        return (
            <div className="blue ui fluid menu">
                <span href="" className="item"></span>
                <a className="item" href="#" onClick={this.loadMap.bind(this)}>
                    <i className="folder icon"></i>
                    Загрузить карту
                    <input type='file' ref={ input => this.fileLoader = input } style={{ 'display': 'none' }} />
                </a>
                
                <span className="item">Инструмент: </span>
                
                {_.keys(tools).map(t => (
                    <a href="#"  key={t} className={cx({
                        'item': true,
                        'active': t === this.state.selectedTool    
                    })}>
                        <i className={cx( tools[t].icon, "icon" )}></i>
                        {tools[t].name}
                    </a>
                ))}
            </div>    
        );
    }
}