import React from 'react'
import './CustomTable.css'

const TableHelper = (props) => {
    return (
        <div className='TableHelper'>
            {props.children}
        </div>
    )
}

export default TableHelper