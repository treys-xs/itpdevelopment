import React, {useState} from "react";
import axios from 'axios'
import {CreateTaskCommentsServer} from "../../api/server/TaskComments/CreateTaskCommentsServer";

interface CreateTaskCommentsProps{
    onCreate: () => void,
    taskId: string
}

interface ITaskCommentsForm {
    commentType: string;
    content: string;
}

export function CreateTaskComments({ onCreate, taskId } : CreateTaskCommentsProps){

    const [contact, setContact] = useState<ITaskCommentsForm>({
        commentType: "",
        content: ""
    });


    const submitHandler = async (event: React.FormEvent) => {
        event.preventDefault()
        CreateTaskCommentsServer({
            taskId: taskId,
            type: contact.commentType,
            content: contact.content
        })
        onCreate()
    }

    return (
        <form onSubmit={submitHandler}>
            Type Comment <input
            type="text"
            className="border py-2 px-4 mb-2 w-full outline-0"
            value={contact.commentType}
            onChange={e => setContact({...contact, commentType: e.target.value})}
        />
            Content <input
            type="text"
            className="border py-2 px-4 mb-2 w-full outline-0"
            value={contact.content}
            onChange={e => setContact({...contact, content: e.target.value})}
        />
            <button className="py-2 px-4 border bg-yellow-400 hover:text-white">Create</button>
        </form>
    );
}