export interface MenuTabPanelProps {
    tabs: Array<MenuTabProps>
}

export interface MenuTabPanelState {
    
}

export interface MenuTabProps {
    title: string,
    reference: string
}

export interface MenuTabState {
    active: boolean
}