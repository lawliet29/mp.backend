import * as React from 'react'
import ElementaryAreasTab from './components.tabs.elementaryAreas'
import WorkAreasTab from './components.tabs.workAreas'
import * as cx from 'classnames'

interface TabsState {
    selectedTab: number
}

interface Tab {
    name: string,
    element: JSX.Element
}

export default class Tabs extends React.Component<{}, TabsState> {
    
    private tabs : Array<Tab> = [
        {
            name: 'Элементарные участки',
            element: <ElementaryAreasTab />
        },
        {
            name: 'Рабочие участки',
            element: <WorkAreasTab />
        },
        {
            name: 'Поля севооборота',
            element: <div></div>
        }
    ]
    
    constructor() {
        super();
        this.state = { selectedTab: 0 };
    }
    
    setTab(index : number) {
        this.setState({ selectedTab: index });
    }

    render() {
        return (    
            <div>
                <div className='ui top attached tabular menu'>
                    {this.tabs.map( (tab, index) => 
                        <a 
                            key={index} 
                            className={cx({ item: true, active: index == this.state.selectedTab })}
                            onClick={this.setTab.bind(this, index)}>
                            {tab.name}
                        </a> 
                    )}
                </div>
                <div className='ui bottom attached segment'>
                    {this.tabs[this.state.selectedTab].element}
                </div>    
            </div>
        );
    }
}