import React, {useState} from "react";
import axios from 'axios'

interface CreateTaskProps{
    onCreate: () => void
    projectId?: string
}

interface ITaskForm {
    name: string;
    description: string;
    startDate: string;
    endDate: string;
}

export function CreateTask({ onCreate, projectId } : CreateTaskProps){

    const [contact, setContact] = useState<ITaskForm>({
        name: "",
        description: "",
        startDate: "",
        endDate: ""
    });

    const submitHandler = async (event: React.FormEvent) => {
        event.preventDefault()
        await axios.post("http://localhost:5031/api/task/create", {
            projectId: projectId,
            description: contact.description,
            name: contact.name,
            startDate: contact.startDate,
            endDate: contact.endDate
        })
        onCreate()
    }

    return (
        <form onSubmit={submitHandler}>
            Name <input
            type="text"
            className="border py-2 px-4 mb-2 w-full outline-0"
            value={contact.name}
            onChange={e => setContact({...contact, name: e.target.value})}
        />
            Description <input
            type="text"
            className="border py-2 px-4 mb-2 w-full outline-0"
            value={contact.description}
            onChange={e => setContact({...contact, description: e.target.value})}
        />
            Start Date <input
            type="text"
            className="border py-2 px-4 mb-2 w-full outline-0"
            value={contact.startDate}
            onChange={e => setContact({...contact, startDate: e.target.value})}
        />
            End Date <input
            type="text"
            className="border py-2 px-4 mb-2 w-full outline-0"
            value={contact.endDate}
            onChange={e => setContact({...contact, endDate: e.target.value})}
        />
            <button className="py-2 px-4 border bg-yellow-400 hover:text-white">Create</button>
        </form>
    );
}
