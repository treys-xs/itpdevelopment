import React, {useContext} from "react";
import {ModalContext} from "../context/ModalContext";
import {Modal} from "../components/Modal";
import {CreateTaskComments} from "../components/TaskComments/CreateTaskComments";
import {useLocation} from "react-router-dom";
import {TaskComments} from "../components/TaskComments/TaskComments";
import {useTaskComments} from "../hooks/taskComments";

export function TaskDetailPage(){
    const { modal, open, close } = useContext(ModalContext)
    const location = useLocation()
    const taskComments = useTaskComments(location.state.task.id)

    return(
        <div>
        <div
            className="block rounded-lg bg-white shadow-[0_2px_15px_-3px_rgba(0,0,0,0.07),0_10px_20px_-2px_rgba(0,0,0,0.04)] dark:bg-neutral-700">
            <div
                className="relative overflow-hidden bg-cover bg-no-repeat"
                data-te-ripple-init
                data-te-ripple-color="light">
                <a href="#!">
                    <div
                        className="absolute bottom-0 left-0 right-0 top-0 h-full w-full overflow-hidden bg-[hsla(0,0%,98%,0.15)] bg-fixed opacity-0 transition duration-300 ease-in-out hover:opacity-100"></div>
                </a>
            </div>
            <div className="p-6">
                <h5
                    className="mb-2 text-xl font-medium leading-tight text-neutral-800 dark:text-neutral-50">
                    {location.state.task.name}
                </h5>
                <p className="mb-4 text-base text-neutral-600 dark:text-neutral-200">
                    description: {location.state.task.description}
                </p>
                <p className="mb-4 text-base text-neutral-600 dark:text-neutral-200">
                    amountTime: {location.state.task.amountTime}
                </p>
                <p className="mb-4 text-base text-neutral-600 dark:text-neutral-200">
                    startDate: {location.state.task.startDate}
                </p>
                <p className="mb-4 text-base text-neutral-600 dark:text-neutral-200">
                    endDate: {location.state.task.endDate}
                </p>
                <p className="mb-4 text-base text-neutral-600 dark:text-neutral-200">
                    createDate: {location.state.task.createDate}
                </p>
            </div>
        </div>
            <div className="container mx-auto max-w-2xl pt-5">
                <div>Comments:</div>
                {taskComments.taskComments.map(taskComment => <TaskComments comment ={taskComment} key={taskComment.id} />)}
            </div>

            {modal && <Modal title="Create new Comment" onClose={close}>
                <CreateTaskComments onCreate={close} taskId={location.state.task.id}/>
            </Modal>}

            <button
                className="absolute bottom-5 right-5 rounded-full bg-red-500 text-white text-2xl px-4 py-2"
                onClick={open}
            >+</button>
        </div>
    );
}