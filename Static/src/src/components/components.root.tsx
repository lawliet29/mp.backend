import * as React from 'react';
import {MenuTabProps} from '../models/menu/models.menu'
import Tabs from './tabs/components.tabs'
import Map from './map/components.map'
import Menu from './menu/components.menu'
import MenuService from '../services/services.menu'
import * as cx from 'classnames'
import * as $ from 'jquery'

declare function require(name) : any;
const styles = require('../styles/page.sass')

export default class RootComponent extends React.Component<{}, {}> {
    
    componentDidMount() {
        setTimeout(() => $(window).resize(), 1500);
    }
    
    render() {
        return (
            <div className='ui grid'>
                <div className="ui one column row">
                    <Menu />
                </div>
                <div className='ui two column row'>
                    <div className={cx({
                        ['ui twelve wide column']: true,
                        [styles.stretched]: true
                    })}>
                        <Map />
                    </div>
                    <div className="ui four wide column">
                        <Tabs />
                    </div>
                </div>
            </div>
        )
    }
}