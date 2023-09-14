import {useEffect, useState} from "react";
import axios from 'axios'
import {ITaskComments} from "../models/ITaskComments";
export function useTaskComments(taskId? : string){
    const [taskComments, setTaskComments] = useState<ITaskComments[]>([])

    async function fetchProjects(){
        const responce = await axios.get<ITaskComments[]>(`http://localhost:5031/api/taskcomment/get/${taskId}`)
        setTaskComments(responce.data)
    }
    useEffect(() =>{
        fetchProjects()
    })

    return {taskComments}
}