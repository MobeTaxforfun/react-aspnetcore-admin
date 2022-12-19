import React from 'react'
import PageCollapse from '../../../components/Collapse/PageCollapse'
import Grid from '@mui/material/Grid';

const UserManage = () => {
    return (
        <Grid container spacing={2}>
            <Grid item xs={8}>
                <PageCollapse>xs=8</PageCollapse>
            </Grid>
            <Grid item xs={4}>
                <PageCollapse>xs=4</PageCollapse>
            </Grid>
            <Grid item xs={4}>
                <PageCollapse>xs=4</PageCollapse>
            </Grid>
            <Grid item xs={8}>
                <PageCollapse>xs=8</PageCollapse>
            </Grid>
        </Grid>
    )
}

export default UserManage