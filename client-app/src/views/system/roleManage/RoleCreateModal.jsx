import React from 'react'
import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogContentText,
} from '@mui/material';
import Grid from '@mui/material/Grid';
import { Button, Box } from '@mui/material';
import {
    Add,
} from '@mui/icons-material';
import BootstrapDialogTitle from '../../../components/AppModal/BootstrapDialogTitle';
import { styled } from '@mui/material/styles';
import Paper from '@mui/material/Paper';

const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
}));

const RoleCreateModal = (props) => {
    const [open, setOpen] = React.useState(false);
    const handleClickOpen = () => {
        setOpen(!open);
    };

    return (
        <React.Fragment>
            <Button variant="contained"
                size={props.size}
                color={props.color}
                startIcon={props.startIcon}
                title={props.modallabel} sx={props.sx} onClick={handleClickOpen}>
                {props.modallabel}
            </Button>
            <Dialog
                fullWidth={true}
                maxWidth={"xs"}
                open={open}
                onClose={handleClickOpen}
            >
                <BootstrapDialogTitle id="customized-dialog-title" onClose={handleClickOpen}>
                    {props.modallabel}
                </BootstrapDialogTitle>
                <DialogContent>
                    <Box
                        noValidate
                        component="form"
                        sx={{
                            display: 'flex',
                            flexDirection: 'column',
                            m: 'auto',
                        }}
                    >
                        <from>
                            <Grid container spacing={2}>
                                <Grid item xs={12} sx={{
                                    display: 'flex',
                                    justifyContent: 'space-around',
                                }}>
                                    <label>角色名称</label>
                                    <input className='form-control'></input>
                                </Grid>
                                <Grid item xs={12}>
                                    <Item>xs=4</Item>
                                </Grid>
                                <Grid item xs={12}>
                                    <Item>xs=4</Item>
                                </Grid>
                                <Grid item xs={12}>
                                    <Item>xs=8</Item>
                                </Grid>
                            </Grid>
                        </from>
                    </Box>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClickOpen}>取消</Button>
                    <Button onClick={handleClickOpen}>確定</Button>
                </DialogActions>
            </Dialog>
        </React.Fragment>
    )
}

export default RoleCreateModal