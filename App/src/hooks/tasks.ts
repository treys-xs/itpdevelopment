import {useEffect, useState} from "react";
import axios from 'axios'
import {ITask} from "../models/ITask";

export function useTasks(nameProject? : string){
    const [tasks, setTasks] = useState<ITask[]>([])
    async function fetchProjects(){
        const responce = await axios.get(`http://localhost:5031/api/task/getall/${nameProject}`)
        setTasks(responce.data)
    }

    useEffect(() => {
        fetchProjects()
    },[])

    return {tasks}
}