import React from 'react'
import { styled } from '@mui/material/styles';
import TableRow from '@mui/material/TableRow';

const StyledTableRow = (props) => {
    const StyledTableRow = styled(TableRow)(({ theme }) => ({
        '&:nth-of-type(odd)': {
            backgroundColor: theme.palette.action.hover,
        },
        // hide last border
        '&:last-child td, &:last-child th': {
            border: 0,
        },
    }));

    return (
        <StyledTableRow>{props.children}</StyledTableRow>
    )
}

export default StyledTableRow