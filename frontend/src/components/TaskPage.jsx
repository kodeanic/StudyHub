import React, { useState } from 'react';
import { Container, Row, Col, Form, Button, ListGroup, Badge } from 'react-bootstrap';

const groups = [
    "8К01", "8К02", "8К03", "8К04"
]

const students = [
    "Семенов Анатолий Дмитриевич", "Тарамалы Сергей Сергеевич"
]

const TaskPage = () => {
    const [tasks, setTasks] = useState([]);
    const [taskInput, setTaskInput] = useState('');
    const [selectedGroup, setSelectedGroup] = useState('');
    const [selectedStudent, setSelectedStudent] = useState('');
    const [taskDescription, setTaskDescription] = useState('');
    const [dueDate, setDueDate] = useState('');
    const [taskTitle, setTaskTitle] = useState('');
    const [subject, setSubject] = useState('');

    const handleTaskInputChange = (e) => {
        setTaskInput(e.target.value);
    };

    const handleSelectedGroupChange = (e) => {
        setSelectedGroup(e.target.value);
    };

    const handleSelectedStudentChange = (e) => {
        setSelectedStudent(e.target.value);
    };

    const handleTaskDescriptionChange = (e) => {
        setTaskDescription(e.target.value);
    };

    const handleDueDateChange = (e) => {
        setDueDate(e.target.value);
    };

    const handleTaskTitleChange = (e) => {
        setTaskTitle(e.target.value);
    };

    const handleSubjectChange = (e) => {
        setSubject(e.target.value);
    };

    const handleAddTask = () => {
        if (taskInput.trim() !== '') {
            setTasks([...tasks, { id: Date.now(), title: taskInput, completed: false }]);
            setTaskInput('');
        }
    };

    const handleToggleTask = (taskId) => {
        setTasks(
            tasks.map((task) =>
                task.id === taskId ? { ...task, completed: !task.completed } : task
            )
        );
    };

    const handleDeleteTask = (taskId) => {
        setTasks(tasks.filter((task) => task.id !== taskId));
    };

    return (
        <Container>
            <Row>
                <Col>
                    <h1>Менеджер задач</h1>
                    <Form>
                        <Form.Group controlId="groupSelect">
                            <Form.Label>Группа:</Form.Label>
                            <Form.Control as="select" onChange={handleSelectedGroupChange}>
                                {groups.map((group, index) => (
                                    <option key={index} value={group}>{group}</option>
                                ))}
                            </Form.Control>
                        </Form.Group>
                        <Form.Group controlId="studentSelect">
                            <Form.Label>Студент:</Form.Label>
                            <Form.Control as="select" onChange={handleSelectedStudentChange}>
                                {students.map((student, index) => (
                                    <option key={index} value={student}>{student}</option>
                                ))}
                            </Form.Control>
                        </Form.Group>
                        <Form.Group controlId="subject">
                            <Form.Label>Предмет</Form.Label>
                            <Form.Control type="text" onChange={handleSubjectChange} />
                        </Form.Group>
                        <Form.Group controlId="taskTitle">
                            <Form.Label>Название задачи</Form.Label>
                            <Form.Control type="text" onChange={handleTaskTitleChange} />
                        </Form.Group>
                        <Form.Group controlId="taskForm">
                            <Form.Label>Описание задачи</Form.Label>
                            <Form.Control as="textarea" rows={3} onChange={handleTaskDescriptionChange} />
                        </Form.Group>
                        <Form.Group controlId="dueDate">
                            <Form.Label>Дата сдачи</Form.Label>
                            <Form.Control type="date" onChange={handleDueDateChange} />
                        </Form.Group>
                        <Button variant="primary" onClick={handleAddTask}>
                            Добавить задачу
                        </Button>
                    </Form>
                </Col>
            </Row>
        </Container>
    );
};

export default TaskPage;
