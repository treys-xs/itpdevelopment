import axios from 'axios'
import {serverApi} from "../../../constants/serverApi";

interface CreateTaskCommentsProps{
    taskId?: string,
    type: string,
    content: string
}
export async function CreateTaskCommentsServer(props : CreateTaskCommentsProps){
    await axios.post(`${serverApi}/taskcomment/create`, {
        taskId: props.taskId,
        type: props.type,
        content: props.content
    })
}