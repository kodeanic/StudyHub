import React from 'react';
import { Container, Row, Col, Breadcrumb } from 'react-bootstrap';

function App() {
  return (
    <>
      <Container>
        <header className='mt-2'>
          <Row>
            <Col md='2'>Logo</Col>
            
            <Col md='6'>Menu</Col>
          </Row>
        </header>
        <Breadcrumb className='mt-4'>
          <Breadcrumb.Item href='#'>Home</Breadcrumb.Item>
          <Breadcrumb.Item href='https://getbootstrap.com/docs/4.0/components/breadcrumb/'>
            Library
          </Breadcrumb.Item>
          <Breadcrumb.Item active>Data</Breadcrumb.Item>
        </Breadcrumb>
      </Container>
    </>
  );
};

export default App;
