import Button from "./Button";

 const Table = ({studyAreas, onDelete, onUpdate}) =>{

    const handleDelete = (id) => {
        onDelete(id);
    }
    const handleUpdate = (id) => {
        onUpdate(id);
    }
    return (
        <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
          </tr>
        </thead>
        <tbody>
          {studyAreas.map((studyArea, index) => (
            <tr key={index}>
              <td>{studyArea.Id}</td>
              <td>{studyArea.Name}</td>
              <td><Button onClick={() => handleDelete(studyArea.Id)} label="Delete" /> </td>
              <td><Button onClick={() => handleUpdate(studyArea.Id)} label = "Edit" /> </td>

            </tr>
          ))}
        </tbody>
      </table>)
}

export default Table;
