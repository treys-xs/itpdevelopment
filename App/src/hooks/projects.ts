import {useEffect, useState} from "react";
import {IProject} from "../models/IProject";
import axios from 'axios'
export function useProjects(){
    const [projects, setProjects] = useState<IProject[]>([])
    async function fetchProjects(){
        const responce = await axios.get("http://localhost:5031/api/project/getall")
        setProjects(responce.data)
    }

    useEffect(() => {
        fetchProjects()
    },[])

    return {projects}
}