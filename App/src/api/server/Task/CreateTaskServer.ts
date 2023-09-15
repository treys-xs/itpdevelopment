import axios from 'axios'
import {serverApi} from "../../../constants/serverApi";

interface CreateTaskServerProps{
    projectId?: string,
    description: string,
    name: string,
    startDate: string,
    endDate: string
}

export async function CreateTaskServer(props : CreateTaskServerProps){
    await axios.post(`${serverApi}/task/create`, {
        projectId: props.projectId,
        description: props.description,
        name: props.name,
        startDate: props.startDate,
        endDate: props.endDate
    })
}