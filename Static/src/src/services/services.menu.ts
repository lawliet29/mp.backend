import {MenuTabProps} from '../models/menu/models.menu'
import * as _ from 'lodash'

const items : Array<MenuTabProps> = [
    { title: 'Home', reference: '/' },
    { title: 'About', reference: '/about' }
];

export interface MenuService {
    getMenuItems() : Array<MenuTabProps>
}

const Service : MenuService = {
    getMenuItems: () => _.cloneDeep(items)
};

var DefaultService = Service;

export default DefaultService;