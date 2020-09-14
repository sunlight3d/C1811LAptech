import React from 'react'
import {sum} from '../calculations/calculations'
/*
export function Header(props) {
    return <div>
        <h2>
            Day la header
        </h2>
    </div>
}
*/
export const Header = ({x, y, name, email}) => {
    const tong = sum(2, 3)
    return <div>
        <h2>
            name = {name}, email = {email}, x = {x}, y = {y}, tong = {tong}
        </h2>
    </div>
}

/*
export class Header extends React.Component {
    render() {
        return <div>
            <h2>
                Day la headefdfjr
        </h2>
        </div>
    }
}
*/