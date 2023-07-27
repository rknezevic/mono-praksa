import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import Form from './components/Form';
import App from './App';
import "./styles.css"
import EditForm from './components/EditForm'
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { createRoot } from 'react-dom/client';

const router = createBrowserRouter ([
  {
    path: "/",
    element: <App/>
  },
  {
    path: "/add",
    element: <Form/>
  },
  {
    path: "/edit/:id",
    element: <EditForm/>
  }
])

createRoot(document.getElementById("root")).render(
  <RouterProvider router = {router}/>
);
