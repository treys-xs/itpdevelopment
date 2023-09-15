import {useEffect, useState} from "react";
import {IProject} from "../models/IProject";
import axios from 'axios'
import {GetAllProjectsServer} from "../api/server/Project/GetAllProjectsServer";
export function useProjects(){
    const [projects, setProjects] = useState<IProject[]>([])
    async function fetchProjects(){
        const response = await GetAllProjectsServer()
        setProjects(response.data)
    }

    useEffect(() => {
        fetchProjects()
    },[])

    return {projects}
}