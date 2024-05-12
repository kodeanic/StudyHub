import React from 'react';
import {Alert, Badge, Button, Container, Nav, Navbar} from "react-bootstrap";

function Header() {
    return (
        <React.Fragment>
            <Navbar bg="dark" data-bs-theme="dark">
                <Container>
                    <Navbar.Brand href="#home">StudyHub</Navbar.Brand>
                    <Nav className="me-auto">
                        <Nav.Link href="#home">Домой</Nav.Link>
                        <Nav.Link href="#features">Задачи</Nav.Link>
                        <Nav.Link href="#pricing">Оценки</Nav.Link>
                    </Nav>
                </Container>
                <Container>
                    <Nav>
                        <Nav.Link href="#account">Аккаунт</Nav.Link>
                    </Nav>
                </Container>
            </Navbar>

            <Button variant="primary">Тык!{' '}
                <Badge bg="secondary">11</Badge>
            </Button>
            <Alert>Важно!</Alert>
        </React.Fragment>
    )
}

export default Header;
