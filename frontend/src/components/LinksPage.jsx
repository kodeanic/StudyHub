import React, { useState } from 'react';
import { Container, Row, Col, Form, Button, Table } from 'react-bootstrap';

const subjects = [
    "Проектирование систем"
]


const NewPage = () => {
    const [selectedSubject, setSelectedSubject] = useState('');
    const [notes, setNotes] = useState('');

    const handleSelectedSubjectChange = (e) => {
        setSelectedSubject(e.target.value);
    };

    const handleNotesChange = (e) => {
        setNotes(e.target.value);
    };

    return (
        <Container>
            <Row>
                <Col>
                    <h1>Выберите дисциплину</h1>
                    <Form.Group controlId="subjectSelect">
                        <Form.Label>Дисциплина</Form.Label>
                        <Form.Control as="select" onChange={handleSelectedSubjectChange}>
                            <option value="">Выберите дисциплину</option>
                            {subjects.map((subject, index) => (
                                <option key={index} value={subject}>{subject}</option>
                            ))}
                        </Form.Control>
                    </Form.Group>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h2>Интернет-ресурсы</h2>
                    <Table striped bordered hover>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Название</th>
                                <th>Ссылка</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Ресурс 1</td>
                                <td><a href="#">Ссылка</a></td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td>Ресурс 2</td>
                                <td><a href="#">Ссылка</a></td>
                            </tr>
                        </tbody>
                    </Table>
                </Col>
            </Row>
            <Row>
                <Col>
                    <h2>Заметки</h2>
                    <Form.Group controlId="notes">
                        <Form.Control as="textarea" rows={5} onChange={handleNotesChange} value={notes} />
                    </Form.Group>
                </Col>
            </Row>
        </Container>
    );
};

export default NewPage;
