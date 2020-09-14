import React, {Component} from 'react'
import {Header} from './components/Header'
import {places} from './calculations/calculations'
export default class Main extends Component {
    componentDidMount() {
    }
    _mapPlacesToUI() {
        return places.map(place => {
            const {name, state, carNumber} = place
        return <ul>
            <li>Name = {name}, state = {state}, carNumber={carNumber}</li>
        </ul>
        })
    }
    render() {
        return <div>
            <Header x = {100} y = {200} name = {"Hoang"} email = {"haong@gmail.com"}/>
            {this._mapPlacesToUI()}
        </div>
    }
}
