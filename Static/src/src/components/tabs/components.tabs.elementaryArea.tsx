import * as React from 'react'
import {ElementaryArea} from '../../models/domain/areas'
import AreaService from '../../services/services.areas'
import * as cx from 'classnames'
import Collapse from '../collapse/component.collapse.tsx' 

declare function require(name) : any;
const styles = require('../../styles/tabs/elementaryArea.sass');

type Props = {
    key: React.Key,
    area: ElementaryArea,
    extended?: boolean
}

type State = {
    isEditing : boolean
    propertiesCollapsed: boolean
}

export default class ElementaryAreaListItem extends React.Component<Props, State> {
    private text : HTMLInputElement;
    
    constructor(props : Props) {
        super(props);
        this.state = {
            isEditing: false,
            propertiesCollapsed: true
        }
    }
    
    updateName(event? : Event) {
        if (this.text) {
            const area = this.props.area;
            area.name = this.text.value;
            this.setEditable(false);
            AreaService.addElementaryArea(area, area.id);
        }
        
        if (event) {
            event.stopPropagation();
            return false;
        }
    }
    
    setEditable(value : boolean) {
        const state = _.clone(this.state);
        state.isEditing = value;
        this.setState(state);
    }
    
    toggleCollapsed() {
        const area = this.props.area;
        area.selected = !area.selected;
        AreaService.triggerAreasChange();
    }
    
    toggleProperties() {
        const state = _.clone(this.state);
        state.propertiesCollapsed = !state.propertiesCollapsed;
        this.setState(state);
    } 
    
    render() {
        const area = this.props.area;
        
        return (
            <div 
                className={cx( { 
                    'ui fluid card': true, 
                    [styles.hoverContainer]: true,
                    [styles.highlighted]: this.props.area.hover
                })} 
                onMouseEnter={AreaService.setHighlight.bind(AreaService, this.props.area.id, true)} 
                onMouseLeave={AreaService.setHighlight.bind(AreaService, this.props.area.id, false)} 
            >
                <div className='content'>
                    <div className="right floated meta">
                        <span className='ui circular basic label'>{area.id}</span>
                    </div>
                    <span className={ cx([ "header", styles.alignedHeader ]) }>
                        { this.state.isEditing
                        ? 
                            <span>
                                <form onSubmit={this.updateName.bind(this)}>
                                    <input type='text' ref={value => { 
                                        this.text = value; 
                                        if (value) {
                                            this.text.value = this.props.area.name;
                                            this.text.focus();
                                        } 
                                    }} />
                                    <div className='right floated'>
                                        <a href='#' onClick={this.updateName.bind(this)}><i className='ui green check icon'></i></a>
                                        <a href='#' onClick={this.setEditable.bind(this, false)}><i className='ui red remove icon'></i></a>
                                    </div>
                                </form>
                            </span>
                        : 
                            <span>
                                { area.name.length == 0 
                                ? 
                                    <em><a href='#' onClick={this.setEditable.bind(this, true)}>&lt;Задать имя&gt;</a></em>
                                : 
                                    <span>
                                        <strong className={ styles.areaName }  onClick={this.toggleCollapsed.bind(this)}>{area.name}</strong>
                                        
                                        <a href='#' onClick={this.setEditable.bind(this, true)} className={cx([ styles.hoverOnly, 'right floated' ])}>
                                            <i className='ui pencil icon'></i>
                                        </a>
                                    </span>
                                }
                            </span>
                        }
                    </span>
                </div>
                
                <div className={cx({
                    "content": true,
                    [styles.collapse]: true,
                    [styles.invisible]: !this.props.area.selected
                })}>
                    <div className="meta">
                        Элементарный участок
                    </div>
                    <div className="">
                        Точек: <strong>{this.props.area.points.length}</strong>
                    </div>
                    
                </div>
                
                <div className={cx({
                    "content": true, 
                    [styles.selfCollapsed]: true,
                    [styles.collapse]: true,
                    [styles.invisible]: this.state.propertiesCollapsed || !this.props.area.selected
                })}>
                    <Collapse name="Информация" data={this.props.area.info} />
                </div>
                
                <div className={cx({
                    "extra content": true,
                    [styles.collapse]: true,
                    [styles.invisible]: !this.props.area.selected
                })}>
                    <div className="fluid ui buttons">
                        <button className="ui basic green icon button" onClick={this.toggleProperties.bind(this)}>
                            <i className="list icon"></i>
                            Подробности
                        </button>
                        <button className="ui basic blue icon button" onClick={AreaService.setEditArea.bind(AreaService, this.props.area.id)}>
                            <i className="pencil icon"></i>
                            {this.props.area.points.length > 0 ? "Перерисовать" : "Нарисовать"}
                        </button>
                        <button className="ui basic red icon button" onClick={AreaService.removeElementaryArea.bind(AreaService, this.props.area.id)}>
                            <i className="remove icon"></i>
                            Удалить
                        </button>
                    </div>
                </div>
                
            </div>
        )
    }
}