import { useRoutes } from "react-router-dom";
import Layout from "../layouts/Layout";
import Login from "../views/login/Login";
import Home from "../views/home/Home";
import MenuManage from "../views/system/menuManage/MenuManage";
import RoleManage from "../views/system/roleManage/RoleManage";
import UserManage from "../views/system/userManage/UserManage";

const GetRouters = () => {
    let element = useRoutes([
        {
            path: "/Login",
            element: <Login />
        },
        {
            element: <Layout />,
            children: [
                {
                    path: "/Home",
                    element: <Home />
                },
                {
                    path: "/UserMag",
                    element: <UserManage />
                },
                {
                    path: "/RoleMag",
                    element: <RoleManage />
                },
                {
                    path: "/MenuMag",
                    element: <MenuManage />
                }]
        },
        {
            path: "*",
            element: <Login />
        }
    ]);

    return element;
}

export default GetRouters