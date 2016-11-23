import * as React from 'react'
import * as cx from 'classnames'
import * as _ from 'lodash'

declare function require(name) : any;
const styles = require('../../styles/tabs/collapse.sass');

type PropsType = {
    name: string,
    data: { [key: string]: (string | {}) }
}
type StateType = { 
    isCollapsed: boolean
}

export default class Collapse extends React.Component<PropsType, StateType> {
    public constructor(props) {
        super(props);
        this.state = {
            isCollapsed: true
        }
    }
    
    handleClick() {
        this.setState(s => {
            s.isCollapsed = !s.isCollapsed;
            return s;
        });
    }
    
    render() {
        
        const grouped = _(this.props.data)
            .map((value, key) =>({ value, key }))
            .groupBy(({value, key}) => !_.isObject(value))
            .value();
        
        if (_.isEmpty(grouped['true']) && _.isEmpty(grouped['false'])) {
            return null;
        }
        
        return (
            <div className='ui fluid card'>
                <div className={cx(['content', styles.collapser])}>
                    <span className={ cx([ "ui small header", styles.alignedHeader ]) }>

                        <a onClick={this.handleClick.bind(this)}>
                            <span>
                                <i className={cx({
                                    'ui small square outline icon': true,
                                    'plus': this.state.isCollapsed,
                                    'minus': !this.state.isCollapsed
                                })} />
                            </span>
                            {this.props.name}
                        </a>
                    </span>
                </div>
                <div className="ui separator"></div>
                <div className={cx({
                    [styles.collapse]: true,
                    [styles.invisible]: this.state.isCollapsed
                })}>
                    {_.isEmpty(grouped['true'])
                        ? null 
                        : (
                            <table className="ui very compact table">
                            <tbody>
                                {_.map(_.filter(grouped['true'], ({value, key}) => value), ({value, key}) => (
                                    <tr key={key}>
                                        <td>{key}:</td>
                                        <td>{value}</td>
                                    </tr>
                                ))}
                            </tbody>
                            </table>
                        )
                    }
                    
                    {_.isEmpty(grouped['false'])
                        ? null
                        : (
                            <div>
                                {_.map(grouped['false'], ({value, key}) => (
                                    <Collapse key={key} name={key} data={value} />
                                ))}
                            </div>
                        )
                    }
               </div>
            </div>
        );
    }
}
