import React, {useContext, useState} from "react";
import {Modal} from "../components/Modal";
import {ModalContext} from "../context/ModalContext";
import {CreateTask} from "../components/Task/CreateTask";
import {Task} from "../components/Task/Task";
import {Params, useLocation, useParams} from "react-router-dom";
import {useTasks} from "../hooks/tasks";

export function TasksPage(){
    const { modal, open, close } = useContext(ModalContext)
    const location = useLocation()
    const nameProject : Params   = useParams<string>();
    const {tasks} = useTasks(nameProject.name)

    return(
        <div className="container mx-auto max-w-2xl pt-5">
            <div>Tasks:</div>
            <div>
                {tasks.map(task => <Task  task={task} key={task.id}/>)}
            </div>

    {modal && <Modal title="Create new Task" onClose={close}>
        <CreateTask onCreate={close} projectId={location.state.projectId} />
    </Modal>}

        <button
            className="absolute bottom-5 right-5 rounded-full bg-red-500 text-white text-2xl px-4 py-2"
            onClick={open}
        >+</button>

        </div>
    );
}