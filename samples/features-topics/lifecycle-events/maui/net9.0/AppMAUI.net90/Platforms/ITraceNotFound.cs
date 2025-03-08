namespace AppMAUI;

public interface 
                                        ITraceNotFound
{
    public
        static
        string
                                        TraceWriteLine
                                        (
                                            string message = "",
                                            [System.Runtime.CompilerServices.CallerMemberName]
                                            string member_name = "",
                                            [System.Runtime.CompilerServices.CallerFilePath]
                                            string source_file_path = "",
                                            [System.Runtime.CompilerServices.CallerLineNumber]
                                            int source_line_number = 0
                                        )
    {
        using ( Cysharp.Text.Utf16ValueStringBuilder sb = Cysharp.Text.ZString.CreateStringBuilder() )
        {
            sb.Append("message : ");
            sb.Append(message);
            sb.AppendLine();
            sb.Append("member_name : ");
            sb.Append(member_name);
            sb.AppendLine();
            sb.Append("source_file_path : ");
            sb.Append(source_file_path);
            sb.AppendLine();
            sb.Append("source_line_number : ");
            sb.Append(source_line_number);
            sb.AppendLine();

            string retval = sb.ToString();
            System.Diagnostics.Trace.WriteLine(retval);
            
            return retval;
        }
    }
}
