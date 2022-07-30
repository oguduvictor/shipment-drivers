import { Container } from 'reactstrap';
import NavMenu from '../nav-menu/nav-menu';
import React from "react";

const Layout = (props: React.PropsWithChildren) => {
    return (
        <div>
            <NavMenu />
            <Container>
                {props.children}
            </Container>
        </div>
    );
}

export default Layout;