
import './App.css';
import CreateTable  from './components/CreateTable';
import { useState } from 'react';
import AddUser from './components/AddUser';
import { useEffect } from 'react';
/*
function App() {
  return (
    <div className="MyFirstReactApp">
      <Textbox />
      <DisplayData />
    </div>
  );
}
*/

const App = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    const storedUsers = localStorage.getItem("users");
    const usersFromStorage = storedUsers ? JSON.parse(storedUsers) : [];
    setUsers(usersFromStorage);
  }, []);

  useEffect(() => {
    if (users.length > 0) {
      localStorage.setItem("users", JSON.stringify(users));
    }
  }, [users]);

  const handleDeleteUser = (userId) => {

    setUsers((prevUsers) => prevUsers.filter((user) => user.id !== userId));

  }

  const handleAddUser = (newUser) => {
    setUsers((prevUsers) => [...prevUsers, newUser]);

    localStorage.setItem("users", JSON.stringify([...users, newUser]));
  };

  return (
    <div>
      <h1>Add Users</h1>
      <AddUser onAddUser = {handleAddUser}/>
      <CreateTable users={users} onDeleteUser = {handleDeleteUser} />
    </div>
  );
};

export default App;
