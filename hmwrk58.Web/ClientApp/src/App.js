import React from 'react';
import { Route } from 'react-router-dom';
import PeopleTable from './PeopleTable';
import AddPerson from './AddPerson';
import AddCarForm from './AddCarForm';
import Layout from './Layout';


const App = () => {
   return (
       <Layout>
           <Route exact path='/' component={PeopleTable} />
           <Route exact path='/addperson' component={AddPerson} />
           <Route exact path='/addcar/:id' component={AddCarForm} />
       </Layout>
   )
}

export default App;

