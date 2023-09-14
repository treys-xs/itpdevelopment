import React, {useContext} from "react";
import {Project} from "../components/Project/Project";
import {Modal} from "../components/Modal";
import {CreateProject} from "../components/Project/CreateProject";
import {ModalContext} from "../context/ModalContext";
import {useProjects} from "../hooks/projects";

export function ProjectsPage(){
    const { modal, open, close } = useContext(ModalContext)
    const {projects} = useProjects();

    return (
        <div className="container mx-auto max-w-2xl pt-5">
            <div>Projects:</div>
            <div>
                {projects.map(project => <Project project={project} key={project.id} />)}
            </div>

            {modal && <Modal title="Create new Project" onClose={close}>
                <CreateProject onCreate={close}/>
            </Modal>}

            <button
                className="absolute bottom-5 right-5 rounded-full bg-red-500 text-white text-2xl px-4 py-2"
                onClick={open}
            >+</button>
        </div>
    );
}