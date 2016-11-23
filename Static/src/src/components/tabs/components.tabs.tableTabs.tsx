import * as React from 'react'
import * as cx from 'classnames'
import * as _ from 'lodash'

type Props = {
    data: { [key: string] : { [name: string] : string } }
}
type State = {
    selectedTab: string
}

const ignore = (...args: any[]) => undefined

export default class TableTabs extends React.Component<Props, State> {
    constructor(props : Props) {
        super(props);
        this.state = {
            selectedTab: _.keys(props.data)[0]
        }
    }
    
    setTab(name : string) {
        this.setState({
            selectedTab: name
        })
    }
    
    render() {
        return (
            <div>
                <div className="ui top attached small tabular menu">
                    {_.keys(this.props.data).map(k => (
                        <a href="#" key={k} className={cx({ "item": true, "active": k === this.state.selectedTab })} onClick={this.setTab.bind(this, k)}>
                            {k}
                        </a>
                    ))}
                </div>
                <div className="ui bottom attached segment">
                    <table className="ui very compact table">
                    <tbody>
                        {_.map(this.props.data[this.state.selectedTab], (value, key) => (
                            <tr key={key}>
                                <td>{key}:</td>
                                <td>{value}</td>
                            </tr>
                        ))}
                    </tbody>
                    </table>
                </div>
            </div>
        );
    }
}