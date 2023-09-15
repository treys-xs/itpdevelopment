import {useEffect, useState} from "react";
import axios from 'axios'
import {ITaskComments} from "../models/ITaskComments";
import {GetTaskCommentsServer} from "../api/server/TaskComments/GetTaskCommentsServer";
export function useTaskComments(taskId? : string){
    const [taskComments, setTaskComments] = useState<ITaskComments[]>([])

    async function fetchProjects(){
        const responce = await GetTaskCommentsServer(taskId)
        setTaskComments(responce.data)
    }
    useEffect(() =>{
        fetchProjects()
    })

    return {taskComments}
}