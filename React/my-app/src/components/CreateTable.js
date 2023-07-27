

const CreateTable = ({ users, onDeleteUser, onEditUser }) => {

  const handleDeleteUser = (userId) =>{
    onDeleteUser(userId);
  }

return(
<table>
  <thead>
    <tr>
      <th>ID</th>
      <th>First Name</th>
      <th>Last Name</th>
      <th>Actions</th>
    </tr>
  </thead>
  <tbody>
    {users.map((user) => (
      <tr key={user.id}>
        <td>{user.id}</td>
        <td>{user.firstName}</td>
        <td>{user.lastName}</td>
        <td> <button> Edit </button> 
        <button onClick={() => handleDeleteUser(user.id)}>Delete</button>
        </td>
      </tr>
    ))}
  </tbody>
</table>

    )
}

export default CreateTable