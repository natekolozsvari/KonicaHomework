import React, { useState } from 'react';
import { Form, Row, Col, Button, Input } from 'reactstrap';

const SearchForm = ({ search }) => {
    const [searchTerm, setSearchTerm] = useState("");

    const handleChange = (e) => {
        setSearchTerm(e.target.value);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        search(searchTerm);
    }

    return (
        <div>
            <Form onSubmit={ handleSubmit }>
                <Row className="align-items-right">
                    <Col xs={8} style={{ paddingRight: "5px" }}>
                        <Input id="searchInput" onChange={handleChange}/>
                    </Col>
                    <Col>
                        <Button type="submit">Search</Button>
                    </Col>
                </Row>
            </Form>
        </div>
    );
}

export default SearchForm;