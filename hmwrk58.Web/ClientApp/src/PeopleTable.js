import React from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import PersonRow from './PersonRow';


class PeopleTable extends React.Component{
    state = {
        people: [],
        person: {
            firstName: '',
            lastName: '',
            age: '',
            cars: []
        }
    }

    componentDidMount = async () => {
        await this.refreshPeople();
    }

    refreshPeople = async () => {
        const { data } = await axios.get('/api/People/GetAll');
        this.setState({ people: data });
    }

    generateTable = () => {
        return <table className='table table-hover table-striped table-bordered'>
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Age</th>
                    <th>Car Count</th>
                    <th>Add Car</th>
                    <th>Delete Cars</th>
                </tr>
            </thead>
            <tbody>
                {this.state.people.map(p => {
                    return <PersonRow
                        person={p}
                        key={p.id}
                        />
                })}
            </tbody>
        </table>
    }

    render() {
        return(
            <div className='container mt-5'>
                <div className='row'>
                    <div className='col-md-12'>
                    <Link to={'/AddPerson'}>
                            <button className='btn btn-success btn-lg btn-block'>Add Person</button>
                        </Link>
                    </div>
                </div>
                <div className='row mt-3'>
                    {this.generateTable()}
                </div>
            </div>
        )
    }

} export default PeopleTable;


