import React from 'react'
import './CustomTable.css'

const SearchList = (props) => {
    return (
        <div className="search-list">
            {props.children}
        </div>
    )
}

export default SearchList