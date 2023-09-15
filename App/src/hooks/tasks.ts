import {useEffect, useState} from "react";
import axios from 'axios'
import {ITask} from "../models/ITask";
import {GetTasksServer} from "../api/server/Task/GetTasksServer";

export function useTasks(nameProject? : string){
    const [tasks, setTasks] = useState<ITask[]>([])
    async function fetchProjects(){
        const responce = await GetTasksServer(nameProject)
        setTasks(responce.data)
    }

    useEffect(() => {
        fetchProjects()
    },[])

    return {tasks}
}