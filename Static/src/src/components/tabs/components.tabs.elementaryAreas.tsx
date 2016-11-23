import * as React from 'react'
import {ElementaryArea} from '../../models/domain/areas'
import AreaService from '../../services/services.areas'
import AreaComponent from './components.tabs.elementaryArea'
import Const from '../../constants'
import * as _ from 'lodash'

type State = { 
    areas: {[id: number] : ElementaryArea},
    activeArea?: number
}

export default class ElementaryAreasTab extends React.Component<{}, State> {
    constructor() {
        super();
        this.state = {
            areas: AreaService.getElementaryAreas()
        }
        AreaService.onAreasChange(() => {
            this.setState({
                areas: AreaService.getElementaryAreas(),
                activeArea: this.state.activeArea
            })    
        });
    }
    
    createEmptyArea() {
        AreaService.addElementaryArea({
            name: '',
            points: []
        })
    }
    
    render() {
        return (
            <div>
                <div>
                    <button className='ui basic button' onClick={this.createEmptyArea}>+</button>
                </div>
                <div className='cards'>
                    {_.map(this.state.areas, (area, id) => <AreaComponent key={id} area={area} />)}
                </div>
            </div>
        )
    }
}