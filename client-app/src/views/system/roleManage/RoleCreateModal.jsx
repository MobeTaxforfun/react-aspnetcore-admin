import React from 'react'
import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogContentText,
    DialogTitle
} from '@mui/material';
import { Button, Box } from '@mui/material';
import {
    Add
} from '@mui/icons-material';

const RoleCreateModal = (props) => {
    const [open, setOpen] = React.useState(false);
    const handleClickOpen = () => {
        setOpen(!open);
    };

    return (
        <React.Fragment>
            <Button variant="contained" size="small" color="success" startIcon={<Add />} title={"新增"} onClick={handleClickOpen}>
                新增
            </Button>
            <Dialog
                fullWidth={true}
                maxWidth={"xl"}
                open={open}
                onClose={handleClickOpen}
            >
                <DialogTitle>Optional sizes</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        You can set my maximum width and whether to adapt or not.
                    </DialogContentText>
                    <Box
                        noValidate
                        component="form"
                        sx={{
                            display: 'flex',
                            flexDirection: 'column',
                            m: 'auto',
                            width: 'fit-content',
                        }}
                    >
                    </Box>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClickOpen}>Close</Button>
                </DialogActions>
            </Dialog>
        </React.Fragment>
    )
}

export default RoleCreateModal