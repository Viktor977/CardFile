

export interface Card {
    id: number;
    title: string;
    author: string;
    article: string;
    datePublish: any;
    allows: number;
    users: Object[];
    reactions: Object[];
}
