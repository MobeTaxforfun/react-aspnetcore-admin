import React from 'react'
import { IconButton } from '@mui/material'

const EmptyButton = (props) => {
    return (
        <IconButton
            aria-label="delete"
            title={props.title}
            sx={{
                width: 30,
                height: 30,
                borderRadius: 0.5,
                border: "1px solid",
                borderColor: "gray"
            }}>
            {props.children}
        </IconButton>
    )
}

export default EmptyButton