import React from "react";
import {IProject} from "../../models/IProject";
import {Link} from "react-router-dom";

interface ProjectProps{
    project: IProject
}
export function Project(props : ProjectProps) {
    return(
        <Link  to={`${props.project.name}/tasks` } state={{projectId: props.project.id}}>
            <button
                className="mt-1 w-96 bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded"
                >
                <div className="flex ...">
                    <div className="flex-1">
                        Name: {props.project.name}
                    </div>
                    <div className="flex-1">
                        Id: {props.project.id}
                    </div>
                </div>
            </button>
        </Link>
    );
}