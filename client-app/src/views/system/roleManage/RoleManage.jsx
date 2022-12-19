import React from 'react'
import Grid from '@mui/material/Grid';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import ButtonGroup from '@mui/material/ButtonGroup';
import IconButton from '@mui/material/IconButton';

import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

import Pagination from '@mui/material/Pagination';

import Stack from '@mui/material/Stack';

import {
    Search,
    FindReplace,
    Add,
    Edit,
    Delete,
    GetApp

} from '@mui/icons-material';

import PageCollapse from '../../../components/Collapse/PageCollapse'
import SearchList from '../../../components/Table/SearchList';
import TableHelper from '../../../components/Table/TableHelper';

const RoleManage = () => {

    const StyledTableCell = styled(TableCell)(({ theme }) => ({
        [`&.${tableCellClasses.head}`]: {
            backgroundColor: "#a3bbd9",
            color: theme.palette.common.white,
        },
        [`&.${tableCellClasses.body}`]: {
            fontSize: 14,
        },
    }));

    const StyledTableRow = styled(TableRow)(({ theme }) => ({
        '&:nth-of-type(odd)': {
            backgroundColor: theme.palette.action.hover,
        },
        // hide last border
        '&:last-child td, &:last-child th': {
            border: 0,
        },
    }));

    function createData(name, code, sort, state, createTime) {
        return { name, code, sort, state, createTime };
    }

    const rows = [
        createData('系統管理員', 'SystemAdmin', 1, '啟用', '2022/12/10'),
        createData('管理員', 'Admin', 2, '啟用', '2022/12/10'),
        createData('一般使用者', 'User', 3, '啟用', '2022/12/10'),
    ];

    return (
        <Grid container spacing={2}>
            <Grid item xs={12}>
                <PageCollapse>
                    <form id="role-form">
                        <SearchList>
                            <ul>
                                <li>
                                    <label>角色名稱：</label>
                                    <input className="form-control form-control-sm" type="text" name="roleName" />
                                </li>
                                <li>
                                    <label>權限標記：</label>
                                    <input className="form-control form-control-sm" name="roleKey" />
                                </li>
                                <li>
                                    <label>角色狀態：</label>
                                    <select className="form-select" aria-label="Default select example">
                                        <option value="">請選擇</option>
                                        <option value="1">正常</option>
                                        <option value="2">停用</option>
                                    </select>
                                </li>
                                <li className="select-time">
                                    <label>創建時間： </label>
                                    <input type="date" className="form-control form-control-sm" id="startTime" placeholder="開始時間" name="params[beginTime]" lay-key="1" />
                                    <span>{'\u00A0'}-{'\u00A0'}</span>
                                    <input type="date" className="form-control form-control-sm" id="endTime" placeholder="結束時間" name="params[endTime]" lay-key="2" />
                                </li>
                                <li>
                                    <Button variant="contained" size="small" color="primary" sx={{ mx: 0.5 }} startIcon={<Search />}>
                                        搜尋
                                    </Button>
                                    <Button variant="contained" size="small" color="warning" sx={{ mx: 0.5 }} startIcon={<FindReplace />}>
                                        重製
                                    </Button>
                                </li>
                            </ul>
                        </SearchList>
                    </form>
                </PageCollapse>
            </Grid>
            <Grid item xs={12}>
                <PageCollapse>
                    <Grid
                        container
                        direction="row"
                        justifyContent="space-between"
                        alignItems="center"
                    >
                        <TableHelper>
                            <Button variant="contained" size="small" color="success" startIcon={<Add />}>
                                新增
                            </Button>
                            <Button variant="contained" size="small" color="primary" startIcon={<Edit />}>
                                修改
                            </Button>
                            <Button variant="contained" size="small" color="error" startIcon={<Delete />}>
                                刪除
                            </Button>
                            <Button variant="contained" size="small" color="warning" startIcon={<Search />}>
                                匯出
                            </Button>
                        </TableHelper>
                        <TableHelper>
                            <IconButton aria-label="delete" sx={{
                                width: 30,
                                height: 30,
                                borderRadius: 0.5,
                                border: "1px solid",
                                borderColor: "gray"
                            }}>
                                <Delete />
                            </IconButton>
                            <IconButton aria-label="delete" sx={{
                                width: 30,
                                height: 30,
                                borderRadius: 0.5,
                                border: "1px solid",
                                borderColor: "gray"
                            }}>
                                <Delete />
                            </IconButton>
                            <IconButton aria-label="delete" sx={{
                                width: 30,
                                height: 30,
                                borderRadius: 0.5,
                                border: "1px solid",
                                borderColor: "gray"
                            }}>
                                <Delete />
                            </IconButton>
                            <IconButton aria-label="delete" sx={{
                                width: 30,
                                height: 30,
                                borderRadius: 0.5,
                                border: "1px solid",
                                borderColor: "gray"
                            }}>
                                <Delete />
                            </IconButton>
                        </TableHelper>
                    </Grid>
                    <Box sx={{ pt: 1, overflow: "auto" }}>
                        <TableContainer component={Paper} sx={{ width: "100%", display: "table", tableLayout: "fixed" }}>
                            <Table sx={{ minWidth: 700 }} aria-label="customized table" size="small">
                                <TableHead>
                                    <TableRow>
                                        <StyledTableCell>#</StyledTableCell>
                                        <StyledTableCell>角色名稱</StyledTableCell>
                                        <StyledTableCell>權限標記</StyledTableCell>
                                        <StyledTableCell>排序</StyledTableCell>
                                        <StyledTableCell>狀態</StyledTableCell>
                                        <StyledTableCell>創建時間</StyledTableCell>
                                        <StyledTableCell align="right">操作</StyledTableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {rows.map((row, index) => (
                                        <StyledTableRow key={row.code}>
                                            <StyledTableCell component="th" scope="row">
                                                {index + 1}
                                            </StyledTableCell>
                                            <StyledTableCell>{row.name}</StyledTableCell>
                                            <StyledTableCell>{row.code}</StyledTableCell>
                                            <StyledTableCell>{row.sort}</StyledTableCell>
                                            <StyledTableCell>{row.state}</StyledTableCell>
                                            <StyledTableCell>{row.createTime}</StyledTableCell>
                                            <StyledTableCell align="right">
                                                <Button variant="contained" size="small" color="primary" startIcon={<Edit />} sx={{ mx: 0.5 }}>
                                                    編輯
                                                </Button>
                                                <Button variant="contained" size="small" color="error" startIcon={<Delete />} sx={{ mx: 0.5 }}>
                                                    刪除
                                                </Button>
                                            </StyledTableCell>
                                        </StyledTableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    </Box>
                    <Stack
                        sx={{ pt: 1 }}
                        direction="row"
                        justifyContent="center"
                        alignItems="center"
                        spacing={2}>
                        <Pagination count={10} />
                    </Stack>
                </PageCollapse>
            </Grid>
        </Grid >
    )
}

export default RoleManage