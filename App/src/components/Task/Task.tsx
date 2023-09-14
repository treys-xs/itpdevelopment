import React from "react";
import {Link} from "react-router-dom";
import {ITask} from "../../models/ITask";

interface TaskProps{
    task: ITask
}
export function Task(props : TaskProps) {
    return(
        <Link relative="path" to={`../../task/${props.task.id}`} state={{task: props.task}}>
            <button
                className="mt-1 w-200 bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded"
                onClick={() => console.log("hello")}
            >
                <div className="flex ...">
                    <div className="flex-1">
                        Id: {props.task.id}
                    </div>
                    <div className="flex-1">
                        Name: {props.task.name}
                    </div>
                    <div className="flex-1">
                        Start Date: {props.task.startDate}
                    </div>
                    <div className="flex-1">
                        End Date: {props.task.endDate}
                    </div>
                    <div className="flex-1">
                        Last Update: {props.task.UpdateDate}
                    </div>
                </div>
            </button>
        </Link>
    );
}