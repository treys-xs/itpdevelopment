import React from "react";
import {IProject} from "../../models/IProject";
import {ITaskComments} from "../../models/ITaskComments";

interface TaskCommentsProps{
    comment: ITaskComments
}
export function TaskComments(props : TaskCommentsProps) {
    return(
                <div className="flex ... mt-1 w-96 bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded">
                    <div className="flex-1">
                        Type: {props.comment.type}
                    </div>
                    <div className="flex-1">
                        Content: {props.comment.content}
                    </div>
                </div>
    );
}